import { useEffect, useState, useContext } from 'react';
import NavLevels from "../Helpers/NavLevels";
import { navContext } from "../src/App";

const useCourses = (schoolYearId) => {

	const [courses, setCourses] = useState();
	const { navigate } = useContext(navContext);

	useEffect(() => {

		const fetchCourses = async () => {
			const response = await fetch('api/courses/' + schoolYearId);
			if (response.status == 200) {
				const courses = await response.json();
				setCourses(courses);
			}
		}
		fetchCourses();

	}, []);

	const addCourse = () => {
		navigate(NavLevels.course, "00000000-0000-0000-0000-000000000000");
	}

	const editCourse = (id) => {
		navigate(NavLevels.course, id);
	}

	return { courses, setCourses, addCourse, editCourse };

}

export default useCourses;