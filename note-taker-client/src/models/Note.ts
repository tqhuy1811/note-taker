class Note {
  constructor(private title: string, private content: string, private id: number){ }

  public getTitle(): string {
    return this.title;
  }

  public getContent(): string {
    return this.content;
  }

  public getId(): number {
    return this.id;
  } 

}

export default Note;