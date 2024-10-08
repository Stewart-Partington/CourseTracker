import React, { useState, useCallback } from 'react';
import ComponentPicker from "./ComponentPicker";
import Breadcrumbs from "./Breadcrumbs";
import NavLevels from "../Helpers/NavLevels";
import NavValues from "../Helpers/NavValues";

const navContext = React.createContext({ nav: null, setNav: () => { } });

const App = () => {

    const navAndSetter = { nav: null, setNav: () => { } };

    const Navigate = useCallback(
        (navLevel, id) => {

            switch (navLevel) {
                case NavLevels.students:

                    NavValues.NavLevel = NavLevels.students;
                    NavValues.Student.Id = null;
                    NavValues.SchoolYear.Id = null;
                    NavValues.Course.Id = null;
                    NavValues.Assessment.Id = null;

                    break;

                case NavLevels.student:

                    NavValues.NavLevel = NavLevels.student;
                    NavValues.Student.Id = id;
                    NavValues.SchoolYear.Id = null;
                    NavValues.Course.Id = null;
                    NavValues.Assessment.Id = null;

                    break;

                case NavLevels.schoolYear:

                    NavValues.NavLevel = NavLevels.schoolYear;
                    NavValues.SchoolYear.Id = id;
                    NavValues.Course.Id = null;
                    NavValues.Assessment.Id = null;

                    break;

                case NavLevels.course:

                    NavValues.NavLevel = NavLevels.course;
                    NavValues.Course.Id = id;
                    NavValues.Assessment.Id = null;

                    break;

                case NavLevels.assessment:

                    NavValues.NavLevel = NavLevels.assessment;
                    NavValues.Assessment.Id = id;

                    break;

                default:

                    NavValues.NavLevel = NavLevels.students;
                    NavValues.Student.Id = null;
                    NavValues.SchoolYear.Id = null;
                    NavValues.Course.Id = null;
                    NavValues.Assessment.Id = null;

                    break;

            }

            const navAndSetter = { nav: { navValues: NavValues, Navigate }, setNav: setNav };

            setNav({ navValues: NavValues, navigate: Navigate, navSetter: setNav });

        }, []
    );

    const [nav, setNav] = useState({ navValues: NavValues, navigate: Navigate, navSetter: null });
    
    return (

        <div className="row">
            <navContext.Provider value={nav}>
                <Breadcrumbs />
                <ComponentPicker navLevel={nav.navValues.NavLevel} />
            </navContext.Provider>
        </div>
    );

}

export { navContext };
export default App;