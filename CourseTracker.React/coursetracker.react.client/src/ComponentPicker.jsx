import Students from "./Students/Students";
import Student from "./Student/Student";
import SchoolYear from "./SchoolYears/SchoolYear";
import NavValues from "../Helpers/NavValues";

const ComponentPicker = ({ currentNavLocation }) => {

	switch (currentNavLocation) {
		case NavValues.students:
			return <Students />;
		case NavValues.student:
			return <Student />;
		case NavValues.schoolYear:
			return <SchoolYear />;
		default:
			return <Students />;
	}

};

export default ComponentPicker;