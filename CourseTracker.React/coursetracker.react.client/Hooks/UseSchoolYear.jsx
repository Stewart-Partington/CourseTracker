import { useEffect, useState } from 'react';
import NavLevels from "../Helpers/NavLevels";

const useSchoolYear = (navValues, navigate, navSetter) => {

	const [schoolYear, setSchoolYear] = useState({});
	const [banner, setBanner] = useState("Getting School Year");
	const [errors, setErrors] = useState({});
	const [schoolYearSaved, setSchoolYearSaved] = useState(schoolYear.id != "00000000-0000-0000-0000-000000000000");

	useEffect(() => {

		const fetchSchoolYear = async () => {
			const response = await fetch('/api/schoolyears/' + navValues.SchoolYear.Id + "/" + navValues.Student.Id);
			const schoolYear = await response.json();
			console.log(schoolYear);
			setSchoolYear(schoolYear);
			setBanner(schoolYear.id == "00000000-0000-0000-0000-000000000000" ? "Add new School Year" : "School Year:" + " " + schoolYear.year);
			setSchoolYearSaved(schoolYear.id == "00000000-0000-0000-0000-000000000000" ? false : true);

			navValues.SchoolYear.Name = schoolYear.id == "00000000-0000-0000-0000-000000000000" ? "Add new School Year" : "School Year: " + schoolYear.year;
			navSetter({ navValues: navValues, navigate: navigate, navSetter: navSetter });

		}
		fetchSchoolYear();

	}, []);

	const saveSchoolYear = async (schoolYear) => {

		var postResponse = await postSchoolYearApi(schoolYear);

		if (postResponse.status === undefined) {
			schoolYear.id = postResponse;
			setSchoolYear(schoolYear);
			setSchoolYearSaved(true);

			navValues.SchoolYear.Name = "School Year: " + schoolYear.year;
			navSetter({ navValues: navValues, navigate: navigate, navSetter: navSetter });

		}
		else {

			let newErrors = {};

			if (postResponse.errors.Index !== undefined)
				newErrors.index = postResponse.errors.Index[0];
			if (postResponse.errors.Year !== undefined)
				newErrors.year = postResponse.errors.Year[0];

			setErrors(newErrors);

		}

	};

	const cancelSchoolYear = () => {
		navigate(NavLevels.student, navValues.Student.Id);
	}

	const deleteSchoolYear = (id) => {
		deleteSchoolYearApi(id);
		navigate(NavLevels.student, navValues.Student.Id);
	}

	const postSchoolYearApi = async (schoolYear) => {

		var result = null;

		await fetch('api/schoolyears', {
			method: "POST",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
			body: JSON.stringify(schoolYear)
		})
			.then((response) => response.json())
			.then((responseData) => {
				console.log(responseData);
				result = responseData;
			});

		return result;

	};

	const deleteSchoolYearApi = async (id) => {
		await fetch('api/schoolyears?id=' + id, {
			method: "DELETE",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
		});
	}

	return { schoolYear, setSchoolYear, saveSchoolYear, banner, cancelSchoolYear, deleteSchoolYear, schoolYearSaved, errors }

};

export default useSchoolYear;
