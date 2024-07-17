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

    return { student, setStudent };

};

export default useStudent;