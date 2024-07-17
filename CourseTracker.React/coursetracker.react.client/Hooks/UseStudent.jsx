import { useEffect, useState } from 'react';

const useStudent = (studentId) => {

	const [student, setStudent] = useState({});

    useEffect(() => {

        const fetchStudent = async () => {
            const response = await fetch('/api/students/' + studentId);
            const student = await response.json();
            console.log(student);
            setStudent(student);
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

    return { student, setStudent, saveStudent };

};

export default useStudent;