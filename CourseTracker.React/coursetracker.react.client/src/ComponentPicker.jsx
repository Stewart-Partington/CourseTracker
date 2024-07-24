import Students from "./Students/Students";
import Student from "./Student/Student";
import SchoolYear from "./SchoolYears/SchoolYear";
import NavLevels from "../Helpers/NavLevels";

const ComponentPicker = ({ navLevel }) => {

	switch (navLevel) {
		case NavLevels.students:
			return <Students />;
		case NavLevels.student:
			return <Student />;
		case NavLevels.schoolYear:
			return <SchoolYear />;
		default:
			return <Students />;
	}

};

export default ComponentPicker;