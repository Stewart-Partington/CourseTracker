import { useEffect, useState } from 'react';
import NavLevels from "../Helpers/NavLevels";

const useCourse = (navValues, navigate, navSetter) => {

	const [course, setCourse] = useState({});
	const [errors, setErrors] = useState({});
	const [courseSaved, setCourseSaved] = useState(course.id != "00000000-0000-0000-0000-000000000000");

	useEffect(() => {

		const fetchCourse = async () => {
			const response = await fetch('/api/courses/' + navValues.Course.Id + "/" + navValues.SchoolYear.Id);
			const course = await response.json();
			console.log(course);
			setCourse(course);
			setCourseSaved(course.id == "00000000-0000-0000-0000-000000000000" ? false : true);

			navValues.Course.Name = course.id == "00000000-0000-0000-0000-000000000000" ? "Add new Course" : "Course: " + course.name;
			navSetter({ navValues: navValues, navigate: navigate, navSetter: navSetter });

		}
		fetchCourse();

	}, []);

	const saveCourse = async (course) => {

		var postResponse = await postCourseApi(course);

		if (postResponse.status === undefined) {
			course.id = postResponse;
			setCourse(course);
			setCourseSaved(true);

			navValues.Course.Id = course.id;
			navValues.Course.Name = "Course: " + course.name;
			navSetter({ navValues: navValues, navigate: navigate, navSetter: navSetter });

		}
		else {

			let newErrors = {};

			if (postResponse.errors.Name !== undefined)
				newErrors.name = postResponse.errors.Name[0];

			setErrors(newErrors);

		}

	};

	const cancelCourse = () => {
		navigate(NavLevels.schoolYear, navValues.SchoolYear.Id);
	}

	const deleteCourse = (id) => {
		deleteCourseApi(id);
		navigate(NavLevels.schoolYear, navValues.SchoolYear.Id);
	}

	const postCourseApi = async (course) => {

		var result = null;

		await fetch('api/courses', {
			method: "POST",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
			body: JSON.stringify(course)
		})
			.then((response) => response.json())
			.then((responseData) => {
				console.log(responseData);
				result = responseData;
			});

		return result;

	};

	const deleteCourseApi = async (id) => {
		await fetch('api/courses?id=' + id, {
			method: "DELETE",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
		});
	}

	return { course, setCourse, saveCourse, cancelCourse, deleteCourse, courseSaved, errors }

}

export default useCourse;