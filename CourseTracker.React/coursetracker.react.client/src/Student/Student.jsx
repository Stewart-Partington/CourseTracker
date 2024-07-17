import { useContext } from "react";
import useStudent from "../../Hooks/UseStudent";
import Banner from "../Banner";
import StudentForm from "./StudentForm";
import { navContext } from "../App";

const Student = () => {

    
    const { param: id } = useContext(navContext);
    const { student, setStudent, saveStudent } = useStudent(id);

    const contents = student.id === undefined
        ?
        <Banner bannerText="Getting Student..." />
        :
        <>
            <Banner bannerText={GetBannerTitleForStudent()} />
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