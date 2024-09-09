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

	const deleteStudent = (id) => {
		deleteStudentApi(id);
	}

	const deleteStudentApi = async (id) => {

		var response = await fetch('api/students?id=' + id, {
			method: "DELETE",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
		});

		if (response.ok) {
			var newStudents = students.filter(function (student) {
				return student.id !== id;
			});
			setStudents(newStudents);
		}

	}

	return { students, setStudents, addStudent, editStudent, deleteStudent };

};

export default useStudents;