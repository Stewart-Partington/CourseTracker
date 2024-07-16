import { useContext } from "react";
import Banner from "../Banner";
import { navContext } from "../App";

const Student = () => {

    const { param: student } = useContext(navContext);

    const contents = 
        <>
            <h1>Student</h1>
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