import { useContext } from 'react';
import { navContext } from "../App";
import useSchoolYear from "../../Hooks/UseSchoolYear";
import Banner from "../Banner";
import SchoolYearForm from "./SchoolYearForm";
import CoursesTable from "../Courses/CoursesTable";

const SchoolYear = () => {

    const { navValues: navValues } = useContext(navContext);
    const { navigate } = useContext(navContext);
    const { navSetter } = useContext(navContext);
    const { schoolYear, setSchoolYear, saveSchoolYear, cancelSchoolYear, schoolYearSaved, errors } = useSchoolYear(navValues, navigate, navSetter);

    const contents = schoolYear.id === undefined
        ?
        <Banner heading={navValues.SchoolYear.Name} />
        :
        <>
            <Banner heading={navValues.SchoolYear.Name} />
            <SchoolYearForm key={schoolYear.id} schoolYear={schoolYear} setSchoolYear={setSchoolYear} saveSchoolYear={saveSchoolYear}
                cancelSchoolYear={cancelSchoolYear} schoolYearSaved={schoolYearSaved} errors={errors} />
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