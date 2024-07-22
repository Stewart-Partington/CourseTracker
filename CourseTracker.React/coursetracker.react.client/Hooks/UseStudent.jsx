import { useEffect, useState, useContext } from 'react';
import { navContext } from "../src/App";
import NavValues from "../Helpers/NavValues";

const useStudent = () => {

	const [student, setStudent] = useState({});
	const [banner, setBanner] = useState("Getting Student");
	const { param: id } = useContext(navContext);
	const { navigate } = useContext(navContext);

    useEffect(() => {

        const fetchStudent = async () => {
            const response = await fetch('/api/students/' + id);
            const student = await response.json();
            console.log(student);
			setStudent(student);
			setBanner(student.id == "00000000-0000-0000-0000-000000000000" ? "Add new Student" : "Student:" + " " + student.firstName);
        }
        fetchStudent();

    }, []);

	const saveStudent = (student) => {
		postStudentApi(student);
		setStudent(student);
	};

	const cancelStudent = () => {
		navigate(NavValues.students);
	}

	const deleteStudent = (id) => {
		deleteStudentApi(id);
		navigate(NavValues.students);
	}

	const postStudentApi = async (student) => {
		await fetch('api/students', {
			method: "POST",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
			body: JSON.stringify(student)
		});
	};

	const deleteStudentApi = async (id) => {
		await fetch('api/students?id=' + id, {
			method: "DELETE",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
		});
	}

	return { student, setStudent, saveStudent, banner, cancelStudent, deleteStudent };

};

export default useStudent;