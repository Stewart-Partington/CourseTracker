import { useEffect, useState } from 'react';

const useStudent = (studentId) => {

	const [student, setStudent] = useState({});
	const [banner, setBanner] = useState("Getting Student");

    useEffect(() => {

        const fetchStudent = async () => {
            const response = await fetch('/api/students/' + studentId);
            const student = await response.json();
            console.log(student);
			setStudent(student);
			setBanner(student.id == null ? "Add new Student" : student.firstName + " " + student.lastName);
        }
        fetchStudent();

    }, []);

	const saveStudent = (student) => {
		postStudent(student);
		setStudent(student);
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