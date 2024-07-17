import { useEffect, useContext, useState } from "react";
import Banner from "../Banner";
import StudentForm from "./StudentForm";
import { navContext } from "../App";

const Student = () => {

    
    const { param: id } = useContext(navContext);
    const [student, setStudent] = useState({});

    useEffect(() => {

        const fetchStudent = async () => {
            const response = await fetch('/api/students/' + id);
            const student = await response.json();
            console.log(student);
            setStudent(student);
        }
        fetchStudent();

    }, []);

    const contents = student.id === undefined
        ?
        <Banner bannerText="Getting Student..." />
        :
        <>
            <Banner bannerText={GetBannerTitleForStudent()} />
            <StudentForm student={student} />
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