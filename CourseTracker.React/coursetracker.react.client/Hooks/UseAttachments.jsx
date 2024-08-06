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

	const addAttachment = () => {
		navigate(NavLevels.attachment, "00000000-0000-0000-0000-000000000000");
	}

	const editAttachment = (id) => {
		navigate(NavLevels.attachment, id);
	}

	return { attachments, setAttachments, addAttachment, editAttachment };

}

export default useAttachments;