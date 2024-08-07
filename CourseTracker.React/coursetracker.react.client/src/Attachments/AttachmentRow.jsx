
const AttachmentRow = ({ attachment, downloadAttachment, navValues }) => {

    const downloadAttachmentClick = (e) => {
        e.preventDefault();
        downloadAttachment(attachment.id);
    };

    return (
        <tr>
            <td>
                <a href={'api/attachments/' + navValues.Assessment.Id + '/' + attachment.id}>Download</a>
            </td>
            <td>{attachment.name}</td>
            <td>{attachment.type}</td>
        </tr>
    );

}

export default AttachmentRow;