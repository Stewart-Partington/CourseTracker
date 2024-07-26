import { useContext } from 'react';
import { navContext } from "../App";
import useSchoolYear from "../../Hooks/UseSchoolYear";
import Banner from "../Banner";
import { bannerContext } from "../App";
import SchoolYearForm from "./SchoolYearForm";
import CoursesTable from "../Courses/CoursesTable";

const SchoolYear = () => {

    const { navValues: navValues } = useContext(navContext);
    const { navigate } = useContext(navContext);
    const { schoolYear, setSchoolYear, saveSchoolYear, banner, cancelSchoolYear, deleteSchoolYear, schoolYearSaved, errors } = useSchoolYear(navValues, navigate);

    const contents = schoolYear.id === undefined
        ?
        <bannerContext.Provider value={{ banner }} >
            <Banner />
        </bannerContext.Provider>
        :
        <>
            <bannerContext.Provider value={{ banner }} >
                <Banner />
            </bannerContext.Provider>
            <SchoolYearForm key={schoolYear.id} schoolYear={schoolYear} setSchoolYear={setSchoolYear} saveSchoolYear={saveSchoolYear}
                cancelSchoolYear={cancelSchoolYear} deleteSchoolYear={deleteSchoolYear} schoolYearSaved={schoolYearSaved} errors={errors} />
            {schoolYearSaved && (
                <CoursesTable schoolYearId={schoolYear.id} />
            )}
        </>

    return (
        <div className="row">
            <div>
                {contents}
            </div>
        </div>
    );

};

export default SchoolYear;