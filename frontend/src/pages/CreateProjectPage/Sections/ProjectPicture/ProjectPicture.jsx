import { useCallback, useEffect } from "react";
import { useDropzone } from "react-dropzone";

import classes from "../../index.module.css";
import DownloadIcon from "../../../../assets/icons/download.svg";

// REQUIRES react-dropzone PACKAGE

const ProjectPicture = ({ insertData }) => {
  const onDrop = useCallback((acceptedFiles) => {
    insertData("images", []);
  }, []);

  const { getRootProps, getInputProps, isDragActive } = useDropzone({ onDrop });

  return (
    <>
      <section className={classes.section}>
        <h3 className={classes.sectionTitle}>Profile picture</h3>
        <p className={classes.sectionDescription}>
          This will be your header picture of your project. You can change this
          later in settings.
        </p>
      </section>
      <div className={classes.sectionDropzone} {...getRootProps()}>
        <input className={classes.sectionDropzoneInput} {...getInputProps()} />
        <img src={DownloadIcon} alt="" />
        <h4>Drag & drop files or Browse</h4>
        <p>Supported formates: JPEG, PNG, GIF, MP4, PDF, PSD, AI, Word, PPT</p>
      </div>
    </>
  );
};

export default ProjectPicture;
