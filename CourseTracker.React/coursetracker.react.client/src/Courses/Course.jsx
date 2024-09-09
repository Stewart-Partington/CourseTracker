import { useContext } from 'react';
import { navContext } from "../App";
import useCourse from "../../Hooks/UseCourse";
import Banner from "../Banner";
import CourseForm from "./CourseForm";
import AssessmentsTable from "../Assessments/AssessmentsTable";

const Course = () => {

    const { navValues: navValues } = useContext(navContext);
    const { navigate } = useContext(navContext);
    const { navSetter } = useContext(navContext);
    const { course, setCourse, saveCourse, cancelCourse, courseSaved, errors } = useCourse(navValues, navigate, navSetter);

    const contents = course.id === undefined
        ?
        <Banner heading={navValues.Course.Name} />
        :
        <>
            <Banner heading={navValues.Course.Name} />
            <CourseForm key={course.id} course={course} setCourse={setCourse} saveCourse={saveCourse}
                cancelCourse={cancelCourse} courseSaved={courseSaved} errors={errors} />
            {courseSaved && (
                <AssessmentsTable courseId={course.id} />
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

export default Course;