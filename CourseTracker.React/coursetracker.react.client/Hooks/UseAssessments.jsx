import { useEffect, useState, useContext } from 'react';
import NavLevels from "../Helpers/NavLevels";
import { navContext } from "../src/App";

const useAssessments = (courseId) => {

	const [assessments, setAssessments] = useState();
	const { navigate } = useContext(navContext);

	useEffect(() => {

		const fetchAssessments = async () => {
			const response = await fetch('api/assessments/' + courseId);
			if (response.status == 200) {
				const assessments = await response.json();
				setAssessments(assessments);
			}
		}
		fetchAssessments();

	}, []);

	const addAssessment = () => {
		navigate(NavLevels.assessment, "00000000-0000-0000-0000-000000000000");
	}

	const editAssessment = (id) => {
		navigate(NavLevels.assessment, id);
	}

	return { assessments, setAssessments, addAssessment, editAssessment };

}

export default useAssessments;
