import React, { useEffect, useState } from 'react';
//import Banner from "./Banner";
import Students from "./Students/Students";
import NavValues from "../Helpers/NavValues";

const navContext = React.createContext(NavValues.students);

function App() {

    return (
        <div className="row">
            <div>
                <Students />
            </div>
        </div>
    );

}

export { navContext };
export default App;