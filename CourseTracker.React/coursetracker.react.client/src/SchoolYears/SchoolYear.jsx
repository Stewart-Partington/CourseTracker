import useSchoolYear from "../../Hooks/UseSchoolYear";
import Banner from "../Banner";
import { bannerContext } from "../App";
import SchoolYearForm from "./SchoolYearForm";

const SchoolYear = () => {

    const { schoolYear, setSchoolYear, saveSchoolYear, banner, errors } = useSchoolYear();

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
            <SchoolYearForm key={schoolYear.id} schoolYear={schoolYear} setSchoolYear={setSchoolYear} saveSchoolYear={saveSchoolYear} errors={errors} />
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