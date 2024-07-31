import { useContext } from 'react';
import { navContext } from "./App";
import NavLevels from "../Helpers/NavLevels";

const Breadcrumbs = () => {

    const { navValues: navValues } = useContext(navContext);
    const { navigate } = useContext(navContext);

    const handleNavClick = (e) => {
        e.preventDefault();

        var navLevel = $(e.target).data("navlevel");
        var id = $(e.target).data("id");

        navigate(navLevel, id);

    }

	const contents = 
        <ol class="breadcrumb mt-3">

            {navValues.NavLevel == NavLevels.students && (
                <li className="breadcrumb-item active">Students</li>
            )}

            {navValues.NavLevel == NavLevels.student && (
                <>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.students} data-id="">Students</a>
                    </li>
                    <li className="breadcrumb-item active">Student: {navValues.Student.Id} </li>
                </>
            )}

            {navValues.NavLevel == NavLevels.schoolYear && (
                <>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.students} data-id="">Students</a>
                    </li>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.student} data-id={navValues.Student.Id} >Student: {navValues.Student.Id}</a>
                    </li>
                    <li className="breadcrumb-item active">School Year: {navValues.SchoolYear.Id} </li>
                </>
            )}

            {navValues.NavLevel == NavLevels.course && (
                <>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.students} data-id="">Students</a>
                    </li>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.student} data-id={navValues.Student.Id} >Student: {navValues.Student.Id}</a>
                    </li>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.schoolYear} data-id={navValues.SchoolYear.Id} >School Year: {navValues.Student.Id}</a>
                    </li>
                    <li className="breadcrumb-item active">Course: {navValues.Course.Id} </li>
                </>
            )}

            {navValues.NavLevel == NavLevels.assessment && (
                <>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.students} data-id="">Students</a>
                    </li>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.student} data-id={navValues.Student.Id} >Student: {navValues.Student.Id}</a>
                    </li>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.schoolYear} data-id={navValues.SchoolYear.Id} >School Year: {navValues.Student.Id}</a>
                    </li>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.course} data-id={navValues.Course.Id} >Course: {navValues.Course.Id}</a>
                    </li>
                    <li className="breadcrumb-item active">Assessment: {navValues.Assessment.Id} </li>
                </>
            )}

	    </ol>

    return (
        <div className="row">
            <div>
                {contents}
            </div>
        </div>
    );

};

export default Breadcrumbs;