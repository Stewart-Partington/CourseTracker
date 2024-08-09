import { useEffect, useState } from 'react';
import NavLevels from "../Helpers/NavLevels";

const useAssessment = (navValues, navigate, navSetter) => {

	const [assessment, setAssessment] = useState({});
	const [banner, setBanner] = useState("Getting Assessment");
	const [errors, setErrors] = useState({});
	const [assessmentSaved, setAssessmentSaved] = useState(assessment.id != "00000000-0000-0000-0000-000000000000");

	useEffect(() => {

		const fetchAssessment = async () => {
			const response = await fetch('/api/assessments/' + navValues.Assessment.Id + "/" + navValues.Course.Id);
			const assessment = await response.json();
			console.log(assessment);
			setAssessment(assessment);
			setBanner(assessment.id == "00000000-0000-0000-0000-000000000000" ? "Add new Assessment" : "Assessment:" + " " + assessment.name);
			setAssessmentSaved(assessment.id == "00000000-0000-0000-0000-000000000000" ? false : true);

			navValues.Assessment.Name = assessment.id == "00000000-0000-0000-0000-000000000000" ? "Add new Assessment" : "Assessment: " + assessment.name;
			navSetter({ navValues: navValues, navigate: navigate, navSetter: navSetter });

		}
		fetchAssessment();

	}, []);

	const saveAssessment = async (assessment) => {

		var postResponse = await postAssessmentApi(assessment);

		if (postResponse.status === undefined) {
			assessment.id = postResponse;
			setAssessment(assessment);
			setAssessmentSaved(true);

			navValues.Assessment.Id = assessment.id;
			navValues.Assessment.Name = "Assessment: " + assessment.name;
			navSetter({ navValues: navValues, navigate: navigate, navSetter: navSetter });

		}
		else {

			let newErrors = {};

			if (postResponse.errors.Name !== undefined)
				newErrors.name = postResponse.errors.Name[0];
			if (postResponse.errors.AssessmentType !== undefined)
				newErrors.assessmentType = postResponse.errors.AssessmentType[0];
			if (postResponse.errors.Weight !== undefined)
				newErrors.weight = postResponse.errors.Weight[0];

			setErrors(newErrors);

		}

	};

	const cancelAssessment = () => {
		navigate(NavLevels.course, navValues.Course.Id);
	}

	const deleteAssessment = (id) => {
		deleteAssessmentApi(id);
		navigate(NavLevels.course, navValues.Course.Id);
	}

	const postAssessmentApi = async (assessment) => {

		var result = null;

		await fetch('api/assessments', {
			method: "POST",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
			body: JSON.stringify(assessment)
		})
			.then((response) => response.json())
			.then((responseData) => {
				console.log(responseData);
				result = responseData;
			});

		return result;

	};

	const deleteAssessmentApi = async (id) => {
		await fetch('api/assessments?id=' + id, {
			method: "DELETE",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
		});
	}

	return { assessment, setAssessment, saveAssessment, banner, cancelAssessment, deleteAssessment, assessmentSaved, errors }

}

export default useAssessment;