import { useEffect, useContext, useState } from "react";
import Banner from "../Banner";
import { navContext } from "../App";

const Student = () => {

    
    const { param: student } = useContext(navContext);
    const [model, setStudent] = useState([]);

    useEffect(() => {
        populateStudentData();
    }, []);

    const contents = student === undefined 
        ?
        <Banner bannerText="Getting Student..." />
        :
        <>
            <Banner bannerText="Got the Student" />
        </>

    return (
        <div className="row">
            <div>
                {contents}
            </div>
        </div>
    );

    async function populateStudentData() {

        var uri = student === null ? '/api/students/00000000-0000-0000-0000-000000000000' : '/api/students/' + student.id;

        await fetch(uri)
            .then(response => response.json())
            .then(json => setStudent(json))
            .catch(error => console.error(error));
    }

}

export default Student;