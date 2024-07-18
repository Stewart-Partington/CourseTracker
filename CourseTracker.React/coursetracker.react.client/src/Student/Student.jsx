import { useContext } from 'react';
import useStudent from "../../Hooks/UseStudent";
import Banner from "../Banner";
import StudentForm from "./StudentForm";
import { navContext } from "../App";
import { bannerContext } from "../App";

const Student = () => {
  
    const { param: id } = useContext(navContext);
    const { student, setStudent, saveStudent, banner } = useStudent(id);

    const contents = student.id === undefined
        ?
        <h1>Getting Student...</h1>
        :
        <>
            <bannerContext.Provider value={{ banner }} >
                <Banner />
            </bannerContext.Provider>
            <StudentForm student={student} setStudent={setStudent} saveStudent={saveStudent} />
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