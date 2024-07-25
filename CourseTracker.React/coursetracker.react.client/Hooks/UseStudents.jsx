import { useEffect, useState } from 'react';
import NavLevels from "../Helpers/NavLevels";

const useStudents = (navigate) => {

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

	const addStudent = () => {
		navigate(NavLevels.student, "00000000-0000-0000-0000-000000000000");
	}

	const editStudent = (id) => {
		navigate(NavLevels.student, id);
	}

	return { students, setStudents, banner, addStudent, editStudent };

};

export default useStudents;