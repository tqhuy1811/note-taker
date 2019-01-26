

class ProgrammingLanguage {
 constructor(private title:string , private id: number) {}

 public getTitle(): string {
   return this.title;
 }

 public getId(): number {
   return this.id;
 }

}

export default ProgrammingLanguage;