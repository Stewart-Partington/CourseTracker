import { useContext } from 'react';
import { navContext } from "../App";
import useStudent from "../../Hooks/UseStudent";
import Banner from "../Banner";
import StudentForm from "./StudentForm";
import YearsTable from "../SchoolYears/YearsTable";

const Student = () => {

    const { navValues: navValues } = useContext(navContext);
    const { navigate } = useContext(navContext);
    const { navSetter } = useContext(navContext);
    const { student, setStudent, saveStudent, cancelStudent, studentSaved, errors } = useStudent(navValues, navigate, navSetter);

    const contents = student.id === undefined
        ?
        <Banner heading={ navValues.Student.Name } />
        :
        <>
            <Banner heading={navValues.Student.Name} />
            <StudentForm key={student.id} student={student} setStudent={setStudent} saveStudent={saveStudent} cancelStudent={cancelStudent}
                studentSaved={studentSaved} errors={errors} />
            {studentSaved && (            
                <YearsTable studentId={student.id} />
            )}
        </>

    return (
        <div className="row">
            <div>
                {contents} 
            </div>
        </div>
    );

}

export default Student;