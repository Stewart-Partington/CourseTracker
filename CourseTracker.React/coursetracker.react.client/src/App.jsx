import React, { useState, useCallback } from 'react';
import ComponentPicker from "./ComponentPicker";;
import NavLevels from "../Helpers/NavLevels";
import NavValues from "../Helpers/NavValues";

const navContext = React.createContext(NavLevels.students);
const bannerContext = React.createContext({ bannerText: "" });

function App() {

    const navigate = useCallback(
        (navLevel, id) => {

            // Rename NavValues. Its not a stack. NavValues?

            var myNav = nav.NavValues;

            switch (navLevel) {
                case NavLevels.students:

                    myNav.NavLevel = NavLevels.students;
                    myNav.Student.Id = null;
                    myNav.SchoolYear.Id = null;
                    myNav.Course.Id = null;
                    myNav.Assesment.Id = null;

                    break;

                case NavLevels.student:

                    myNav.NavLevel = NavLevels.student;
                    myNav.Student.Id = id;
                    myNav.SchoolYear.Id = null;
                    myNav.Course.Id = null;
                    myNav.Assesment.Id = null;

                    break;

                case NavLevels.schoolYear:

                    myNav.NavLevel = NavLevels.schoolYear;
                    myNav.SchoolYear.Id = id;
                    myNav.Course.Id = null;
                    myNav.Assesment.Id = null;

                    break;

                case NavLevels.course:

                    myNav.NavLevel = NavLevels.course;
                    myNav.Course.Id = id;
                    myNav.Assesment.Id = null;

                    break;

                case NavLevels.assessment:

                    myNav.navLevel = NavLevels.assessment;
                    myNave.Assesment.Id = id;

                    break;

                default:

                    myNav.NavLevel = NavLevels.students;
                    myNav.Student.Id = null;
                    myNav.SchoolYear.Id = null;
                    myNav.Course.Id = null;
                    myNav.Assesment.Id = null;

                    break;

            }

            setNav({ NavValues: myNav, id, navigate })

        }, []
    );

    const [nav, setNav] = useState({ NavValues: NavValues, navigate });

    return (

        <div className="row">
            <navContext.Provider value={nav}>    
                <ComponentPicker navLevel={nav.NavValues.NavLevel} />
            </navContext.Provider>
        </div>
    );

}

export { navContext };
export { bannerContext };
export default App;