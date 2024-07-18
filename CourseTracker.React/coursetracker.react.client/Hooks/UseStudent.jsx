import { useEffect, useState } from 'react';
import { bannerContext } from "../src/App";

const useStudent = (studentId) => {

	const [student, setStudent] = useState({});
	const [banner, setBanner] = useState();

    useEffect(() => {

        const fetchStudent = async () => {
            const response = await fetch('/api/students/' + studentId);
            const student = await response.json();
            console.log(student);
			setStudent(student);
			setBanner(student.id == "00000000-0000-0000-0000-000000000000" ? "Add new Student" : student.firstName + " " + student.lastName);
        }
        fetchStudent();

    }, []);

	const saveStudent = (student) => {
		postStudent(student);
		setStudent(student);
		//setBanner("Hey there you handsome mofo!");
	};

	const postStudent = async (student) => {
		await fetch('api/students', {
			method: "POST",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
			body: JSON.stringify(student)
		});
	};

    return { student, setStudent, saveStudent, banner };

};

export default useStudent;