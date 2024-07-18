import { useContext, useState } from 'react';
import useStudent from "../../Hooks/UseStudent";
import Banner from "../Banner";
import StudentForm from "./StudentForm";
import { navContext } from "../App";
import { bannerContext } from "../App";

const Student = () => {
  
    const { param: id } = useContext(navContext);
    const { student, setStudent, saveStudent, banner, setBanner } = useStudent(id);

    const contents = student.id === undefined
        ?
        <h1>Getting Student...</h1>
        :
        <>
            <bannerContext.Provider value={{ banner, setBanner }} >
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

    function GetBannerTitleForStudent() {

        var result = null;

        if (student.id == "00000000-0000-0000-0000-000000000000")
            result = "Add new Student";
        else
            result = student.firstName + " " + student.lastName;

        return result;

    }

}

export default Student;