import { useContext } from 'react';
import { navContext } from "../App";
import useStudent from "../../Hooks/UseStudent";
import Banner from "../Banner";
import StudentForm from "./StudentForm";
import { bannerContext } from "../App";
import YearsTable from "../SchoolYears/YearsTable";

const Student = () => {

    const { navValues: navValues } = useContext(navContext);
    const { navigate } = useContext(navContext);
    const { student, setStudent, saveStudent, banner, cancelStudent, deleteStudent, studentSaved, errors } = useStudent(navValues, navigate);

    const contents = student.id === undefined
        ?
        <bannerContext.Provider value={{ banner }} >
            <Banner />
        </bannerContext.Provider>
        :
        <>
            <bannerContext.Provider value={{ banner }} >
                <Banner />
            </bannerContext.Provider>
            <StudentForm key={student.id} student={student} setStudent={setStudent} saveStudent={saveStudent} cancelStudent={cancelStudent} deleteStudent={deleteStudent}
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