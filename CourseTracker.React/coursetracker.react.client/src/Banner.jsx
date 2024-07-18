import { useContext } from 'react';
import { bannerContext } from "./App";

const Banner = () => {

	const { banner, setBanner } = useContext(bannerContext);

	return (
		<h1>{banner}</h1>
	);

};

export default Banner;