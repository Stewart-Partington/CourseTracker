import { useEffect, useState, useContext } from 'react';
import { navContext } from "../src/App";
import NavLevels from "../Helpers/NavLevels";

const useSchoolYear = () => {

	const [schoolYear, setSchoolYear] = useState({});
	const [banner, setBanner] = useState("Getting School Year");
	const [errors, setErrors] = useState({});
	const [schoolYearSaved, setSchoolYearSaved] = useState(schoolYear.id != "00000000-0000-0000-0000-000000000000");
	const { id: id } = useContext(navContext);
	const { navigate } = useContext(navContext);

	useEffect(() => {

		const fetchSchoolYear = async () => {
			const response = await fetch('/api/schoolyears/' + id + "/false");
			const schoolYear = await response.json();
			console.log(schoolYear);
			setSchoolYear(schoolYear);
			setBanner(schoolYear.id == "00000000-0000-0000-0000-000000000000" ? "Add new School Year" : "School Year:" + " " + schoolYear.year);
			setSchoolYearSaved(schoolYear.id == "00000000-0000-0000-0000-000000000000" ? false : true);
		}
		fetchSchoolYear();

	}, []);

	const saveSchoolYear = async (schoolYear) => {

		// Needs a studentid. Create a Nav object for:
		// Using parent ids for post calls.
		// Breadcrumbs.
		// Nav library.
		var postResponse = await postSchoolYearApi(schoolYear);

		if (postResponse.status === undefined) {
			schoolYear.id = postResponse;
			setSchoolYear(student);
			setSchoolYearSaved(true);
		}
		else {

			let newErrors = {};

			if (postResponse.errors.Index !== undefined)
				newErrors.index = postResponse.errors.Index[0];
			if (postResponse.errors.year !== undefined)
				newErrors.year = postResponse.errors.Year[0];

			setErrors(newErrors);

		}

	};

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

	return { schoolYear, setSchoolYear, saveSchoolYear, banner, errors }
	//return { student, setStudent, saveStudent, banner, cancelStudent, deleteStudent, studentSaved, errors };

};

export default useSchoolYear;
