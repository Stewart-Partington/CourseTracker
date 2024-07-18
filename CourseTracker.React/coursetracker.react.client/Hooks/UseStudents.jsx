import { useEffect, useState } from 'react';

const useStudents = () => {

	const [students, setStudents] = useState();
	const [banner, setBanner] = useState("Getting Students...");

	useEffect(() => {

		const fetchStudents = async () => {
			const response = await fetch('/api/students');
			if (response.status == 200) {
				const students = await response.json();
				setStudents(students);
				setBanner("Students");
			}
		}
		fetchStudents();

	}, []);

	return { students, setStudents, banner };

};

export default useStudents;