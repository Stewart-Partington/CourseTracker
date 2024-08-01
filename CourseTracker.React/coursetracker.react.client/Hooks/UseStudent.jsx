import { useEffect, useState } from 'react';
import NavLevels from "../Helpers/NavLevels";

const useStudent = (navValues, navigate, navSetter) => {

	const [student, setStudent] = useState({});
	const [errors, setErrors] = useState({});
	const [studentSaved, setStudentSaved] = useState(student.id != "00000000-0000-0000-0000-000000000000");

    useEffect(() => {

        const fetchStudent = async () => {
			const response = await fetch('/api/students/' + navValues.Student.Id);
            const student = await response.json();
            console.log(student);
			setStudent(student);
			setStudentSaved(student.id == "00000000-0000-0000-0000-000000000000" ? false : true);

			navValues.Student.Name = student.id == "00000000-0000-0000-0000-000000000000" ? "Add new Student" : "Student: " + student.firstName;
			navSetter({ navValues: navValues, navigate: navigate, navSetter: navSetter });

        }
        fetchStudent();

    }, []);

	const saveStudent = async (student) => {

		var postResponse = await postStudentApi(student);	

		if (postResponse.status === undefined) {
			student.id = postResponse;
			setStudent(student);
			setStudentSaved(true);

			navValues.Student.Id = student.id;
			navValues.Student.Name = "Student: " + student.firstName;
			navSetter({ navValues: navValues, navigate: navigate, navSetter: navSetter });

		}
		else {

			let newErrors = {};

			if (postResponse.errors.FirstName !== undefined)
				newErrors.firstName = postResponse.errors.FirstName[0];
			if (postResponse.errors.LastName !== undefined)
				newErrors.lastName = postResponse.errors.LastName[0];
			if (postResponse.errors.ProgramName !== undefined)
				newErrors.programName = postResponse.errors.ProgramName[0];

			setErrors(newErrors);

		}

	};

	const cancelStudent = () => {
		navigate(NavLevels.students, null);
	}

	const deleteStudent = (id) => {
		deleteStudentApi(id);
		navigate(NavLevels.students, null);
	}

	const postStudentApi = async (student) => {

		var result = null;

		await fetch('api/students', {
			method: "POST",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
			body: JSON.stringify(student)
		})
			.then((response) => response.json())
			.then((responseData) => {
				console.log(responseData);
				result = responseData;
			});

		return result;

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

	return { student, setStudent, saveStudent, cancelStudent, deleteStudent, studentSaved, errors };

};

export default useStudent;