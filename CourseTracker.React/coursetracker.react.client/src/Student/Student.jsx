import useStudent from "../../Hooks/UseStudent";
import Banner from "../Banner";
import StudentForm from "./StudentForm";
import { bannerContext } from "../App";
import YearsTable from "./YearsTable";

const Student = () => {

    const { student, setStudent, saveStudent, banner, cancelStudent, deleteStudent, studentSaved, errors, getSchoolYears } = useStudent();

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
                <YearsTable getSchoolYears={getSchoolYears} />
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