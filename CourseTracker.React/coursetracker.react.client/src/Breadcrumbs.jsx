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
                    <li className="breadcrumb-item active">{navValues.Student.Name} </li>
                </>
            )}

            {navValues.NavLevel == NavLevels.schoolYear && (
                <>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.students} data-id="">Students</a>
                    </li>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.student} data-id={navValues.Student.Id} >Student: {navValues.Student.Name}</a>
                    </li>
                    <li className="breadcrumb-item active">{navValues.SchoolYear.Name} </li>
                </>
            )}

            {navValues.NavLevel == NavLevels.course && (
                <>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.students} data-id="">Students</a>
                    </li>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.student} data-id={navValues.Student.Id} >Student: {navValues.Student.Name}</a>
                    </li>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.schoolYear} data-id={navValues.SchoolYear.Id} >School Year: {navValues.SchoolYear.Name}</a>
                    </li>
                    <li className="breadcrumb-item active">{navValues.Course.Name} </li>
                </>
            )}

            {navValues.NavLevel == NavLevels.assessment && (
                <>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.students} data-id="">Students</a>
                    </li>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.student} data-id={navValues.Student.Id} >Student: {navValues.Student.Name}</a>
                    </li>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.schoolYear} data-id={navValues.SchoolYear.Id} >School Year: {navValues.SchoolYear.Name}</a>
                    </li>
                    <li className="breadcrumb-item" onClick={handleNavClick}>
                        <a href="#" data-navlevel={NavLevels.course} data-id={navValues.Course.Id} >Course: {navValues.Course.Name}</a>
                    </li>
                    <li className="breadcrumb-item active">{navValues.Assessment.Name} </li>
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