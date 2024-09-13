import React, { createContext } from "react";
import useConfirmDelete from "../Hooks/UseConfirmDelete";

export const DeleteContext = createContext({
	modalShow: false,
	setModalShow: () => { },
	deleteUri: "",
	setDeleteUri: () => { }
});

export const DeleteModalProvider = ({ children }) => {

	const {
		modalShow,
		setModalShow,
		deleteRecord,
		//deleteUri,
		//setDeleteUri
	} = useConfirmDelete();

	const value = {
		modalShow,
		setModalShow,
		deleteRecord,
		//deleteUri,
		//setDeleteUri
	};

	return (
		<DeleteContext.Provider value={value}>
			{children}
		</DeleteContext.Provider>
	);

};