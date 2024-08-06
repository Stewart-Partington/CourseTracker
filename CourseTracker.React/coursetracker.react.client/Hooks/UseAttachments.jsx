import { useEffect, useState, useContext } from 'react';
import NavLevels from "../Helpers/NavLevels";
import { navContext } from "../src/App";

const useAttachments = (assessmentId) => {

	const [attachments, setAttachments] = useState();
	const { navigate } = useContext(navContext);

	useEffect(() => {

		const fetchAttachments = async () => {
			const response = await fetch('api/attachments/' + assessmentId);
			if (response.status == 200) {
				const attachments = await response.json();
				setAttachments(attachments);
			}
		}
		fetchAttachments();

	}, []);

	const addAttachment = (e) => {
		
		const formData = new FormData();

		formData.append('file', attachments);
		formData.append('fileName', attachments.name);

		fetch('api/attachments', {
			method: 'POST',
			headers: {
				//"Content-Type": 'multipart/form-data'
				//"Content-Type": undefined
				'Accept': '*/*'
			},
			body: formData
		}).then(
			response => response.json() // if the response is a JSON object
		).then(
			success => console.log(success) // Handle the success response object
		).catch(
			error => console.log(error) // Handle the error response object
		);

	}

	const editAttachment = (id) => {
		navigate(NavLevels.attachment, id);
	}

	return { attachments, setAttachments, addAttachment, editAttachment };

}

export default useAttachments;