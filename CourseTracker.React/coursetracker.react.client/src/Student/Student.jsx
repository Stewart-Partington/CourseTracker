import { useContext } from 'react';
import useStudent from "../../Hooks/UseStudent";
import Banner from "../Banner";
import StudentForm from "./StudentForm";
import { navContext } from "../App";
import { bannerContext } from "../App";

const Student = () => {
  
    const { param: id } = useContext(navContext);
    const { student, setStudent, saveStudent, banner, cancelStudent } = useStudent(id);

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
            <StudentForm student={student} setStudent={setStudent} saveStudent={saveStudent} cancelStudent={cancelStudent} />
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