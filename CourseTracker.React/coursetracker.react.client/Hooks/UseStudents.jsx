import { useEffect, useState } from 'react';

const useStudents = () => {

	const [students, setStudents] = useState();
	const [banner, setBanner] = useState();

	useEffect(() => {
		setBanner("Students");
		populateStudentsData();
	}, []);

	async function populateStudentsData() {
		await fetch('/api/students')
			.then(response => response.json())
			.then(json => setStudents(json))
			.catch(error => console.error(error));
	};

	return { students, setStudents, banner };

};

export default useStudents;