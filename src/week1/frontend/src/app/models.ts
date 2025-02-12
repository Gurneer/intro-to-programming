/*{
    "id": "d5a4d976-7678-4b0a-8903-20d635970eba",
    "description": "One More Example",
    "completed": false,
    "createdOn": "2025-02-11T13:25:04.9437617-03:00",
    "completedOn": null
  }*/

export type TodoListItem = {
  id: string;
  description: string;
  completed: boolean;
  createdOn: string;
  completedOn?: string;
};
