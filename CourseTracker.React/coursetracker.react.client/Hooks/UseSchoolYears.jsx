import { useEffect, useState, useContext } from 'react';
import NavLevels from "../Helpers/NavLevels";
import { navContext } from "../src/App";

const useSchoolYears = (studentId) => {

	const [schoolYears, setSchoolYears] = useState();
	const { navigate } = useContext(navContext);

	useEffect(() => {

		const fetchSchoolYears = async () => {
			const response = await fetch('api/schoolyears/' + studentId);
			if (response.status == 200) {
				const schoolYears = await response.json();
				setSchoolYears(schoolYears);
			}
		}
		fetchSchoolYears();

	}, []);

	const addSchoolYear = () => {
		navigate(NavLevels.schoolYear, "00000000-0000-0000-0000-000000000000");
	}

	const editSchoolYear = (id) => {
		navigate(NavLevels.schoolYear, id);
	}

	const deleteSchoolYear = (id) => {
		deleteSchoolYearApi(id);
	}

	const deleteSchoolYearApi = async (id) => {

		var response = await fetch('api/schoolyears?id=' + id, {
			method: "DELETE",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
		});

		if (response.ok) {
			var newSchoolYears = schoolYears.filter(function (schoolYear) {
				return schoolYear.id !== id;
			});
			setSchoolYears(newSchoolYears);
		}

	}

	return { schoolYears, setSchoolYears, addSchoolYear, editSchoolYear, deleteSchoolYear };

};

export default useSchoolYears;