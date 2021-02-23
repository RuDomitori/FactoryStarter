using System.Collections.Generic;
using System.Linq;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Levels;

namespace FactoryStarter.Core.Constructions.Rpn {
    internal class Interpreter {
        private Level _level;
        private TypeRepository _types;

        internal Interpreter(Level level, TypeRepository repository) {
            _level = level;
            _types = repository;
        }

        internal void Interpret(Construction construction) {
            var magazine = new Stack<(int Number, string Str)>();
            var k = 0;
            var rpn = construction.Type.Logic[construction.State];
            
            while (k < rpn.Count) {
                (int, string) value = (rpn[k].Number, rpn[k].Str);
                switch (rpn[k].Type) {
                    case Elem.ElemType.Arg:
                        magazine.Push(value);
                        break;
                    case Elem.ElemType.TryCraft:
                        var target = new ItemBunch(new ItemBunchDto {
                            Count = magazine.Pop().Number,
                            TypeId = magazine.Pop().Number
                        }, _types);

                        var requiredItemCount = magazine.Pop().Number;
                        var requiredItems = new List<ItemBunch>(requiredItemCount);
                        for (int i = 0; i < requiredItemCount; i++)
                            requiredItems.Add(new ItemBunch(new ItemBunchDto {
                                Count = magazine.Pop().Number,
                                TypeId = magazine.Pop().Number
                            }, _types));

                        var craftResult = construction.TryCraft(target, requiredItems);
                        if(craftResult) magazine.Push((1, null));
                        else magazine.Push((0, null));
                        
                        break;
                }
                k++;
            }
        }
    }
}