import { useState } from "react";

const useConfirmDelete = () => {

	const [modalShow, setModalShow] = useState(false);

	const [deleteUri, setDeleteUri] = useState("");

	const deleteRecord = () => {


	}

	return { modalShow, setModalShow, deleteRecord
		//deleteUri,
		//setDeleteUri
	};

}

export default useConfirmDelete;