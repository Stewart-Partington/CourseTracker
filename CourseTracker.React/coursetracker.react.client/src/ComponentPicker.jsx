import Students from "./Students/Students";
import Student from "./Student/Student";
import SchoolYear from "./SchoolYears/SchoolYear";
import Course from "./Courses/Course";
import NavLevels from "../Helpers/NavLevels";

const ComponentPicker = ({ navLevel }) => {

	switch (navLevel) {
		case NavLevels.students:
			return <Students />;
		case NavLevels.student:
			return <Student />;
		case NavLevels.schoolYear:
			return <SchoolYear />;
		case NavLevels.course:
			return <Course />;
		default:
			return <Students />;
	}

};

export default ComponentPicker;