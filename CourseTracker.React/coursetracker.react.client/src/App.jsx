import React, { useState, useCallback } from 'react';
import ComponentPicker from "./ComponentPicker";;
import NavLevels from "../Helpers/NavLevels";

const navContext = React.createContext(NavLevels.students);
const bannerContext = React.createContext({ bannerText: "" });

function App() {

    const navigate = useCallback(
        (navTo, param) => setNav({ current: navTo, param, navigate }), [] 
    );
    const [nav, setNav] = useState({ current: NavLevels.Students, navigate });

    return (

        <div className="row">
            <navContext.Provider value={nav}>    
                <ComponentPicker currentNavLocation={nav.current} />
            </navContext.Provider>
        </div>
    );

}

export { navContext };
export { bannerContext };
export default App;