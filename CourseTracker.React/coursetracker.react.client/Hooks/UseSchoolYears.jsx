import { useEffect, useState, useContext } from 'react';
import NavValues from "../Helpers/NavValues";
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
		navigate(NavValues.schoolYear, "00000000-0000-0000-0000-000000000000");
	}

	return { schoolYears, setSchoolYears, addSchoolYear };

};

export default useSchoolYears;