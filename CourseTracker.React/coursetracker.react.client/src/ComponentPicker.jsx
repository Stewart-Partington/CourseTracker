import Students from "./Students/Students";
import Student from "./Student/Student";
import NavValues from "../Helpers/NavValues";

const ComponentPicker = ({ currentNavLocation }) => {

	switch (currentNavLocation) {
		case NavValues.students:
			return <Students />;
		case NavValues.student:
			return <Student />;
		default:
			return <Students />;

	}

};

export default ComponentPicker;