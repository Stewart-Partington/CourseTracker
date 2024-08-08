import { useEffect, useState } from 'react';
import NavLevels from "../Helpers/NavLevels";

const useStudents = (navigate) => {

	const [students, setStudents] = useState();

	useEffect(() => {

		const fetchStudents = async () => {
			const response = await fetch('/api/students');
			if (response.status == 200) {
				const students = await response.json();
				setStudents(students);
			}
		}
		fetchStudents();

	}, []);

	const addStudent = () => {
		navigate(NavLevels.student, "00000000-0000-0000-0000-000000000000");
	}

	const editStudent = (id) => {
		navigate(NavLevels.student, id);
	}

	return { students, setStudents, addStudent, editStudent };

};

export default useStudents;