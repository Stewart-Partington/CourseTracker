import { useContext } from 'react';
import { navContext } from "../App";
import useCourse from "../../Hooks/UseCourse";
import Banner from "../Banner";
import { bannerContext } from "../App";
import CourseForm from "./CourseForm";

const SchoolYear = () => {

    const { navValues: navValues } = useContext(navContext);
    const { navigate } = useContext(navContext);
    const { course, setCourse, saveCourse, banner, cancelCourse, deleteCourse, courseSaved, errors } = useCourse(navValues, navigate);

    const contents = course.id === undefined
        ?
        <bannerContext.Provider value={{ banner }} >
            <Banner />
        </bannerContext.Provider>
        :
        <>
            <bannerContext.Provider value={{ banner }} >
                <Banner />
            </bannerContext.Provider>
            <CourseForm key={course.id} course={course} setCourse={setCourse} saveCourse={saveCourse}
                cancelCourse={cancelCourse} deleteCourse={deleteCourse} courseSaved={courseSaved} errors={errors} />
            
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