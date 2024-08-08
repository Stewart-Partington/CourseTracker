import { useEffect, useState, useContext } from 'react';
import { navContext } from "../src/App";

const useAttachments = (assessmentId, navValues) => {

	const [attachment, setAttachment] = useState();
	const [attachments, setAttachments] = useState();
	//const { navigate } = useContext(navContext);

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

	const addAttachment = async (e) => {
		
		const formData = new FormData();

		formData.append('file', attachment);
		formData.append('fileName', attachment.name);

		await fetch('api/attachments', {
			method: 'POST',
			headers: {
				'studentId': navValues.Student.Id,
				'schoolYearId': navValues.SchoolYear.Id,
				'courseId': navValues.Course.Id,
				'assessmentId': navValues.Assessment.Id,
				'Accept': '*/*'
			},
			body: formData
		}).then(
			response => response.json()
		).then(
			success => console.log(success)
		).catch(
			error => console.log(error) 
		);

		const getResponse = await fetch('api/attachments/' + assessmentId);
		if (getResponse.status == 200) {
			const attachments = await getResponse.json();
			setAttachments(attachments);
		}

	}

	const deleteAttachment = async (id) => {

		var response = await fetch('api/attachments?id=' + id, {
			method: "DELETE",
			headers: {
				Accept: "application/json",
				"Content-Type": "application/json",
			},
		});

		if (response.ok) {
			var newAttachments = attachments.filter(function (attachment) {
				return attachment.id !== id;
			});
			setAttachments(newAttachments);
		}

	}

	return { attachments, setAttachment, addAttachment, deleteAttachment };

}

export default useAttachments;