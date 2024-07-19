import { useEffect, useState, useContext } from 'react';
import NavValues from "../Helpers/NavValues";
import { navContext } from "../src/App";

const useStudents = () => {

	const [students, setStudents] = useState();
	const [banner, setBanner] = useState("Getting Students...");
	const { navigate } = useContext(navContext);

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
		navigate(NavValues.student, "00000000-0000-0000-0000-000000000000");
	}

	const editStudent = (id) => {
		navigate(NavValues.student, id);
	}

	return { students, setStudents, banner, addStudent, editStudent };

};

export default useStudents;