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

	const deleteCourse = (id) => {
		deleteCourseApi(id);
	}

	const deleteCourseApi = async (id) => {

		var response = await fetch('api/courses?id=' + id, {
			method: "DELETE",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
		});

		if (response.ok) {
			var newCourses = courses.filter(function (course) {
				return course.id !== id;
			});
			setCourses(newCourses);
		}

	}

	return { courses, setCourses, addCourse, editCourse, deleteCourse };

}

export default useCourses;